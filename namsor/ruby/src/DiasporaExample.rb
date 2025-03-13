require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::PersonalApi.new.diaspora(
        "US", # country_iso2
        "Keith", # first_name
        "Haring", # last_name
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#diaspora: #{e}"
end
