using AsmResolver.PE.File;
using Serilog;
using Serilog.Events;
using vtortola.WebSockets;
using vtortola.WebSockets.Rfc6455;

namespace license_server
{
    public static class Server
    {
#if DEBUG
        private const LogEventLevel MinimumLevel = LogEventLevel.Debug;
#else
        private const LogEventLevel MinimumLevel = LogEventLevel.Information;
#endif

        private static void SetupLogger()
        {
            var logConfig = new LoggerConfiguration();
            logConfig.WriteTo.Console(MinimumLevel);
            logConfig.MinimumLevel.Is(MinimumLevel);

            Log.Logger = logConfig.CreateLogger();
        }

        private static async Task Main()
        {
            SetupLogger();

            HydrogenLibrary.Initialize();
            
            // Setup image.
            var peFile = PEFile.FromFile("sekai-licensing.exe");
            ChallengeVm.SetupImage(peFile);
            
            // Start the server.
            var cancellation = new CancellationTokenSource();

            var options = new WebSocketListenerOptions();
            options.Standards.RegisterRfc6455();

            var listenEndPoints = new Uri[] {
                new("ws://0.0.0.0:80")
            };
            
            Log.Information("Starting server...");
            
            var server = new WebSocketListener(listenEndPoints, options);
            await server.StartAsync().WaitAsync(cancellation.Token);
            
            Log.Information("Server started.");
            
            await AcceptWebSocketsAsync(server, cancellation.Token);
        }

        private static async Task AcceptWebSocketsAsync(WebSocketListener server, CancellationToken cancellation)
        {
            await Task.Yield();

            while (!cancellation.IsCancellationRequested)
            {
                try
                {
                    var webSocket = await server.AcceptWebSocketAsync(cancellation).ConfigureAwait(false);
                    if (webSocket == null)
                    {
                        if (cancellation.IsCancellationRequested || !server.IsStarted)
                            break; // Stopped.

                        continue; // Retry.
                    }

#pragma warning disable 4014
                    ProcessMessagesAsync(webSocket, cancellation);
#pragma warning restore 4014
                }
                catch (OperationCanceledException)
                {
                    // Server is stopping.
                    break;
                }
                catch (Exception exception)
                {
                    Log.Error("An error occurred while accepting client. ({ex})", exception);
                }
            }

            Log.Information("Server has stopped accepting new clients.");
        }

        private static async Task ProcessMessagesAsync(WebSocket webSocket, CancellationToken cancellation)
        {
            Log.Information("Client '" + webSocket.RemoteEndpoint + "' connected.");
            
            var licenseContext = new LicenseContext(webSocket, cancellation);
            
            try
            {
                while (webSocket.IsConnected && !cancellation.IsCancellationRequested)
                {
                    try
                    {
                        var message = await webSocket.ReadMessageAsync(cancellation);
                        if (message == null)
                            break;

                        var readyForClose = await licenseContext.ProcessMessageAsync(message);
                        if (readyForClose)
                            break;
                    }
                    catch (TaskCanceledException)
                    {
                        break;
                    }
                    catch (Exception exception)
                    {
                        Log.Error("An error occurred while processing message. {ex}", exception);
                        break;
                    }
                }

                // Close socket.
                await webSocket.CloseAsync(WebSocketCloseReason.NormalClose);
            }
            finally
            {
                // Always dispose socket after use.
                webSocket.Dispose();
                Log.Information("Client '" + webSocket.RemoteEndpoint + "' disconnected.");
            }
        }
    }
}