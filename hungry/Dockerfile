FROM maven:3.5.3-jdk-10-slim AS build-env
WORKDIR /src
COPY pom.xml /src/
RUN mvn verify clean --fail-never
COPY . /src/
RUN mvn package

FROM openjdk:10.0.1-10-jre-slim
COPY --from=build-env /src/target/hungry-1.0.0.jar /app.jar
ENTRYPOINT ["java","-Djava.security.egd=file:/dev/./urandom","-jar","/app.jar"]