FROM docker.elastic.co/logstash/logstash:7.15.1

USER root
RUN mkdir -p /dbdriver
RUN curl -L -o /dbdriver/postgresql-42.2.8.jar https://jdbc.postgresql.org/download/postgresql-42.2.8.jar
# ADD ./pipeline/ /usr/share/logstash/pipeline/
# COPY pipeline/logstash.conf ./etc/logstash/conf.d/
# RUN logstash -f /etc/logstash/conf.d/logstash.conf 
# ADD ./config /usr/share/logstash/config/

# RUN bin/logstash-plugin install logstash-input-jdbc