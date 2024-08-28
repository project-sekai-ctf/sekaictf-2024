FROM mcr.microsoft.com/dotnet/aspnet:7.0

RUN useradd -m ctf

COPY flag.txt /flag.txt
RUN mv /flag.txt /flag_`cat /proc/sys/kernel/random/uuid`.txt

RUN chown root:root /flag_*.txt
RUN chmod 444 /flag_*.txt

WORKDIR /app/src

COPY src .
RUN chown -R ctf:ctf /app/src/
RUN chmod -R +w /app/src/

USER ctf
EXPOSE 80
ENTRYPOINT ["dotnet", "CRUD.dll"]
