require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

begin
    NamsorClient::AdminApi.new.learnable_1(
        "source", # source
        true, # learnable
    )
rescue NamsorClient::ApiError => e
    puts "Exception when calling AdminApi#learnable_1: #{e}"
end
