require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::JapaneseApi.new.japanese_name_kanji_candidates_1(
        "Sanae", # japanese_surname_latin
        "Yamamoto", # japanese_given_name_latin
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling JapaneseApi#japanese_name_kanji_candidates_1: #{e}"
end
