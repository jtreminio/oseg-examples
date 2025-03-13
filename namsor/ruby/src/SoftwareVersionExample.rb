require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::AdminApi.new.software_version

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling AdminApi#software_version: #{e}"
end
