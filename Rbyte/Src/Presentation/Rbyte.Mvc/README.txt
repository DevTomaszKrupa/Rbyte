1. Konfiguracja projektu

Do poprawnego działania projektu nalezy utworzyć pliki:
  - appsettings.Development.json
  - connectionString.Development.json  
  
  analogicznie do istniejących juŻ
  - appsettings.json
  - connectionString.json
  
  oraz uzupełnić parametry podane między znakami $$ (w pliku z przedrostkiem .Development)
  Przykład: 
  $$DATABASE$$ -> MySql
  $$SERVER_NAME$$ -> localhost
  $$DATABASE_NAME$$ -> Rbyte
  $$USER_NAME$$ -> admin
  $$USER_PASSWORD$$ -> admin

  Przykładowy connectionString.Development.json:
  {
  "MySqlConnectionString": "server=localhost;database=Rbyte;user=root;password=admin",
  "PostgreSqlConnectionString": "server=$$SERVER_NAME$$;database=$$DATABASE_NAME$$;Username=$$USER_NAME$$;Password=$$USER_PASSWORD$$"
  }


  2. Operacje na bazie
  - wykonujemy w projekcie Rbyte.Persistance
  Update-Database -Context $$ContextName$$
	ex: Update-Database -Context PostgreSqlRbyteContext
  Add-Migration $$NAME$$ -Context $$ContextName$$ -o $$OutputFolder$$
	ex: Add-Migration AddProdcutEntity -Context PostgreSqlRbyteContext -o PostgreSql\Migrations

	// TODO LOGGER