require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

begin
    NamsorClient::AdminApi.new.anonymize(
        "source", # source
        true, # anonymized
    )
rescue NamsorClient::ApiError => e
    puts "Exception when calling AdminApi#anonymize: #{e}"
end
