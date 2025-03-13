require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::PersonalApi.new.country_fn_ln(
        "Keith", # first_name
        "Haring", # last_name
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#country_fn_ln: #{e}"
end
