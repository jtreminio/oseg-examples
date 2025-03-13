require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::SocialApi.new.phone_code_geo(
        "Teniola", # first_name
        "Apata", # last_name
        "08186472651", # phone_number
        "NG", # country_iso2
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling SocialApi#phone_code_geo: #{e}"
end
