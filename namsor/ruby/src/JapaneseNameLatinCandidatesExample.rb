require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::JapaneseApi.new.japanese_name_latin_candidates(
        "塩田", # japanese_surname_kanji
        "千春", # japanese_given_name_kanji
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling JapaneseApi#japanese_name_latin_candidates: #{e}"
end
