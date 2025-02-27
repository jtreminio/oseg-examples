require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::JapaneseApi.new.parse_japanese_name(
        "小島 秀夫", # japanese_name
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling JapaneseApi#parse_japanese_name: #{e}"
end
