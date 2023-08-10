# Usage

```bash
# Localhost
$ curl http://localhost:8080 -d 'Hello world!'
$ curl http://localhost:8080
Hello world!

# Reverse proxy
$ curl https://clipdrop.example.com -d 'Hello world!'
$ curl https://clipdrop.example.com
Hello world!

# Misc
## Clear clipboard
$ curl https://clipdrop.example.com -d ''
```
