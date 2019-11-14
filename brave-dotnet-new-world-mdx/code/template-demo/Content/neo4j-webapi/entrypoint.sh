#!/bin/bash          


if [ "$RUN_MIGRATIONS" = "true" ] ; then
    echo "Pausing for $SECONDS_PAUSE_BEFORE_MIGRATION seconds to let Neo4j warm up"
    sleep $SECONDS_PAUSE_BEFORE_MIGRATION

    echo "Running migrations"
    for filename in /app/data/migrations/*.cypher; do
        echo "Attempting to run cypher: $filename" 
        contents=$( cat $filename )
        cypher-shell -a bolt://ProjectShortName-graphdb:7687 -u neo4j -p neo4jpassword "$contents"
    done
else
    echo "Skipping migrations because RUN_MIGRATIONS was not set to true."
fi

echo "Starting the .NET WebAPI"
dotnet run