#!/usr/bin/env bash

CLIPDROP_URL=${CLIPDROP_URL:-https://clipdrop.example.com}

if [ "$#" -ne 0 ]
then
	curl $CLIPDROP_URL -d "$*"
elif [ ! -t 0 ]
then
	DATA=$(cat)
	curl $CLIPDROP_URL -d "$DATA"
else
	curl $CLIPDROP_URL
fi
