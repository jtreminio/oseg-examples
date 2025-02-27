require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::PersonalApi.new.origin_full(
        "Keith Haring", # personal_name_full
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#origin_full: #{e}"
end
