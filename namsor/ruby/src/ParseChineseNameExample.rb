require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::ChineseApi.new.parse_chinese_name(
        "赵丽颖", # chinese_name
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling ChineseApi#parse_chinese_name: #{e}"
end
