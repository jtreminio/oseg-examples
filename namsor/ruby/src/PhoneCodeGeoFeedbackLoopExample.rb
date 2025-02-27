require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::SocialApi.new.phone_code_geo_feedback_loop(
        "Teniola", # first_name
        "Apata", # last_name
        "08186472651", # phone_number
        "", # phone_number_e164
        "NG", # country_iso2
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling SocialApi#phone_code_geo_feedback_loop: #{e}"
end
