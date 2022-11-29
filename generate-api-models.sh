docker run --rm -v "${PWD}:/local" openapitools/openapi-generator-cli generate \
    -i /local/reference/jobs-in-finland.yaml \
    -g csharp-netcore \
    -o /local/ \
    --global-property=apiTests=false,modelTests=false,modelDocs=false \
    -c /local/config.yaml
