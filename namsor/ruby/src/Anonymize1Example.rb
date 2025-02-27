require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::AdminApi.new.anonymize_1(
        "source", # source
        true, # anonymized
        "token", # token
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling AdminApi#anonymize_1: #{e}"
end
