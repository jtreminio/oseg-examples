require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::SocialApi.new.phone_code(
        "Jamini", # first_name
        "Roy", # last_name
        "09804201420", # phone_number
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling SocialApi#phone_code: #{e}"
end
