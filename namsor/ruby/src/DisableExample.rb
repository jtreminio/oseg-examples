require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

begin
    NamsorClient::AdminApi.new.disable(
        "source", # source
        true, # disabled
    )
rescue NamsorClient::ApiError => e
    puts "Exception when calling AdminApi#disable: #{e}"
end
