require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::ChineseApi.new.chinese_name_match(
        "Yu", # chinese_surname_latin
        "Hong", # chinese_given_name_latin
        "喻红", # chinese_name
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling ChineseApi#chinese_name_match: #{e}"
end
