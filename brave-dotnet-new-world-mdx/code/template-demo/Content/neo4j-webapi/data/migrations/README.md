# About the Migrations folder

Any `.cypher` files placed here will be run in order if migrations are enabled in your docker container.

To disable these scripts from running, set `RUN_MIGRATIONS=false` in `docker-compose.yml`

One migration is included by default -- the migration that helps us set up the sample data for the `dotnet new` template.

**NOTE**: These 'migrations' are just a loop over some files, and not a robust migration system. Your mileage may vary.