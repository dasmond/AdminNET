FROM node:16-alpine as build

WORKDIR /app
COPY package*.json /app/
COPY . .
RUN yarn
RUN yarn build
COPY ./dist/ /usr/share/nginx/html
COPY /_nginx/nginx.conf /etc/nginx/nginx.conf
COPY /_nginx/env.js /etc/nginx/env.js
COPY /_nginx/default.conf /etc/nginx/conf.d/default.conf

CMD ["nginx", "-g", "daemon off;"]
