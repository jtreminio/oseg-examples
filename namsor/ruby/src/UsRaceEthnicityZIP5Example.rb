require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::PersonalApi.new.us_race_ethnicity_zip5(
        "Keith", # first_name
        "Haring", # last_name
        "12345", # zip5_code
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#us_race_ethnicity_zip5: #{e}"
end
