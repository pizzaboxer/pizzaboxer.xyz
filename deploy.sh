#!/bin/sh

PUBLISHDIR=bin/Release/net8.0/linux-x64/publish

MACHINE=pizza-server.internal.pizzaboxer.xyz
SERVICE=pizzaboxer.xyz.service

DOMAIN=pizzaboxer.xyz
SUBDOMAIN=www

rm -r $PUBLISHDIR
dotnet publish -c Release -r linux-x64 --no-self-contained
scp -r $PUBLISHDIR $MACHINE:/var/www/$DOMAIN/$SUBDOMAIN.staging
echo "sudo password required for server"
ssh -t $MACHINE "cd /var/www/$DOMAIN; sudo systemctl stop $SERVICE; rm -r $SUBDOMAIN; mv $SUBDOMAIN.staging $SUBDOMAIN; sudo systemctl start $SERVICE; systemctl status $SERVICE;"