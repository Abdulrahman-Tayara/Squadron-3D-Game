using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class LocalStorageProviderImpl : ILocalStorageProvider {

    private static LocalStorageProviderImpl INSTANCE;

    public static LocalStorageProviderImpl getInstance() {
        if (INSTANCE == null)
            INSTANCE = new LocalStorageProviderImpl();
        return INSTANCE;
    }

    private LocalStorageProviderImpl() { }

    public string readFile(string path) {
        StreamReader reader = new StreamReader(path);
        string data = reader.ReadToEnd();
        reader.Close();
        return data;
    }

    public void writeFile(string path, string data) {
        StreamWriter writer = new StreamWriter(path);
        writer.Write(data);
        writer.Close();
    }
}

