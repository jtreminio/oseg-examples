require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::JapaneseApi.new.gender_japanese_name_pinyin(
        "中松", # japanese_surname
        "義郎", # japanese_given_name
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling JapaneseApi#gender_japanese_name_pinyin: #{e}"
end
