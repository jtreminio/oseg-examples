require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::PersonalApi.new.religion_2(
        "NG", # country_iso2
        "IN-UP", # sub_division_iso31662
        "Akash", # first_name
        "Sharma", # last_name
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#religion_2: #{e}"
end
