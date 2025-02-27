require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::JapaneseApi.new.gender_japanese_name_full(
        "中松 義郎", # japanese_name
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling JapaneseApi#gender_japanese_name_full: #{e}"
end
