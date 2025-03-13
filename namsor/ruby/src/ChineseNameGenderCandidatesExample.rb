require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::ChineseApi.new.chinese_name_gender_candidates(
        "Hong", # chinese_surname_latin
        "Yu", # chinese_given_name_latin
        "m", # known_gender
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling ChineseApi#chinese_name_gender_candidates: #{e}"
end
