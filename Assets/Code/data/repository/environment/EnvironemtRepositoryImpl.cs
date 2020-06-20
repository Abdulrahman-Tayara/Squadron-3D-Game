using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EnvironemtRepositoryImpl : IEnvironmentRepository {

    private static EnvironemtRepositoryImpl INSTANCE;

    private ILocalStorageProvider localStorage;
    private JsonMapper jsonMapper;

    private EnvironemtRepositoryImpl(ILocalStorageProvider localStorage, JsonMapper jsonMapper) {
        this.localStorage = localStorage;
        this.jsonMapper = jsonMapper;
    }

    public static EnvironemtRepositoryImpl getInstance(ILocalStorageProvider localStorage, JsonMapper jsonMapper) {
        if (INSTANCE == null)
            INSTANCE = new EnvironemtRepositoryImpl(localStorage, jsonMapper);
        return INSTANCE;
    }

    public Task<List<Environment>> getEnvironments() {
        return Task.Run(() => {
            string data = localStorage.readFile(ResourcesPath.ENVIRONMENTS_FILE);
            return jsonMapper.fromJsonArray<Environment>(data);
        });
    }
}
