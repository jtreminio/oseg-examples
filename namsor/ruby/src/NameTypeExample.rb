require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::GeneralApi.new.name_type(
        "Zippo", # proper_noun
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling GeneralApi#name_type: #{e}"
end
