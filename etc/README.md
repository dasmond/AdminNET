 # Pre-requirements

* Docker Desktop with Kubernetes enabled
* Install [NGINX ingress](https://kubernetes.github.io/ingress-nginx/deploy/) for k8s
OR
* Install NGINX ingress using helm
```powershell
helm repo add ingress-nginx https://kubernetes.github.io/ingress-nginx
helm repo update

helm upgrade --install --version=4.0.19 ingress-nginx ingress-nginx/ingress-nginx
```
* Install [Helm](https://helm.sh/docs/intro/install/) for running helm charts


# How to run?

* Add entries to the hosts file (in Windows: `C:\Windows\System32\drivers\etc\hosts`):

````powershell
	127.0.0.1       elasticsearch
	127.0.0.1       rabbitmq
	127.0.0.1       redis
	127.0.0.1       postgres-db
	127.0.0.1       backend
````

* Run `build-images.ps1` in the `scripts` directory.
* Run `deploy-staging.ps1` in the `helm-chart` directory. It is deployed with the `admin_net` namespace.
* *You may wait ~30 seconds on first run for preparing the database*.
* Browse https://fontend for public and https://backend for web application
* Username: `admin`, password: `123456`.

# Running on HTTPS

You can also run the staging solution on your local kubernetes kluster with https. There are various ways to create self-signed certificate. 

## Installing mkcert
This guide will use mkcert to create self-signed certificates.

Follow the [installation guide](https://github.com/FiloSottile/mkcert#installation) to install mkcert.

## Creating mkcert Root CA
Use the command to create root (local) certificate authority for your certificates:
```powershell
mkcert -install
```

**Note:** all the certificates created by mkcert certificate creation will be trusted by local machine

## Run mkcert

Create certificate for the admin.net domains using the mkcert command below:
```powershell
mkcert "backend" 
```

At the end of the output you will see something like

The certificate is at "./backend+10.pem" and the key at "./backend+10-key.pem"

Copy the cert name and key name below to create tls secret

```powershell
kubectl create namespace admin_net
kubectl create secret tls -n admin_net admin_net-wildcard-tls --cert=./backend+10.pem  --key=./backend+10-key.pem
```
