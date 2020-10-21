# Perf tester

## Tools

### Apache Benchmark examples

Examples how to perf test [Amazerrr](https://github.com/JanneMattila/amazerrr)
Azure Functions API:

```bash
# Test setup using test image
ab -p Test1.png \
   -T image/png \
   -c 1 \
   -n 1 \
   https://<yourapp>.azurewebsites.net/api/Solver

# Test using example file (see below)
ab \
  -p file.txt \
  -T text/plain \
  -c 50 \
  -n 250000 \
  -s 99999 \
  -k \
  -r \
   https://<yourapp>.azurewebsites.net/api/Solver

# Test using example file (see below)
ab \
  -p file2.txt \
  -T text/plain \
  -c 10 \
  -n 2500 \
  -s 99999 \
  -k \
  -r \
   https://<yourapp>.azurewebsites.net/api/Solver
```

`file.txt`: ASCII text, with CRLF line terminators:

```txt
WWWWWW
W....W
WWWW.W
Wo...W
WWWWWW
```

`file2.txt`: ASCII text, with CRLF line terminators:

```txt
WWWWWWWWWWWWW
W.....WW....W
W.W.W.WW.WW.W
W.W.W.WW.WW.W
W.W.W.WW.WW.W
W.W.W...o.W.W
W.W.......W.W
W.W..WWWW.W.W
W.WW.W.W..W.W
W.WW...W.WW.W
W.WWWW.W.WW.W
W......W....W
WWWWWWWWWWWWW
```