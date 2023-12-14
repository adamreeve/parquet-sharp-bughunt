# Build
```bash
podman build -f Dockerfile.alpine -t localhost/parquet-sharp-bughunt:alpine
podman build -f Dockerfile.debian -t localhost/parquet-sharp-bughunt:debian
```

# Run
```bash
podman run --rm localhost/parquet-sharp-bughunt:alpine
podman run --rm localhost/parquet-sharp-bughunt:debian
```

# Expected result
Both containers display "Hello, World!" showing that they completed writing the parquet file

# Actual result
Debian works as expected, Alpine crashes with error code 139 (segmentation fault).
