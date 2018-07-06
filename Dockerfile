FROM node:10.4.1-alpine
RUN npm install -g serve@9.2.0
WORKDIR /app
EXPOSE 5000
COPY src/package.json src/package-lock.json /app/
RUN npm install
COPY src /app/
RUN npm run build
CMD [ "serve", "-s", "build" ]