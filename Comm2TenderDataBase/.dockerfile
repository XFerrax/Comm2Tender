FROM postgres:15.8-alpine
COPY sql.sql /docker-entrypoint-initdb.d/
ENV POSTGRES_USER $POSTGRES_USER
ENV POSTGRES_PASSWORD $POSTGRES_PASSWORD
ENV POSTGRES_DB $POSTGRES_DB
RUN psql -U $POSTGRES_USER -d $POSTGRES_DB -a -f /docker-entrypoint-initdb.d/sql.sql