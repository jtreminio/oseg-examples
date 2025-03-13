require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::PersonalApi.new.gender_full(
        "Keith Haring", # full_name
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#gender_full: #{e}"
end
