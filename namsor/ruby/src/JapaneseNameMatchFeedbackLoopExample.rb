require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::JapaneseApi.new.japanese_name_match_feedback_loop(
        "Tessai", # japanese_surname_latin
        "Tomioka", # japanese_given_name_latin
        "富岡 鉄斎", # japanese_name
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling JapaneseApi#japanese_name_match_feedback_loop: #{e}"
end
