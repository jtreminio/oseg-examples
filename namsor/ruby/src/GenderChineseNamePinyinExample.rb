require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::ChineseApi.new.gender_chinese_name_pinyin(
        "Dèng", # chinese_surname_latin
        "Qīngyún", # chinese_given_name_latin
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling ChineseApi#gender_chinese_name_pinyin: #{e}"
end
