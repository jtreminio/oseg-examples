require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

begin
    NamsorClient::AdminApi.new.anonymize(
        "source", # source
        true, # anonymized
    )
rescue NamsorClient::ApiError => e
    puts "Exception when calling AdminApi#anonymize: #{e}"
end
