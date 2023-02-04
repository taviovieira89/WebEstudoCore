FROM node:latest as angular
WORKDIR /app
COPY package.json /app
RUN npm install --silent
COPY . .
EXPOSE 3000
RUN npm run build

FROM nginx:alpine
VOLUME /var/cache/nginx
COPY --from=angular app/dist/web-estudo-front /usr/share/nginx/html
COPY ./config/nginx.conf /etc/ngix/conf.d/default.conf

# docker build -t WebEstudoFront .
# docker run -p 8081:80 WebEstudoFront

