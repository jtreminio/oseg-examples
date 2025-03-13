require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::AdminApi.new.api_key_info

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling AdminApi#api_key_info: #{e}"
end
