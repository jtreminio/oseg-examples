require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

personal_names_1 = NamsorClient::FirstLastNameIn.new
personal_names_1.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42"
personal_names_1.first_name = "塩田"
personal_names_1.last_name = "千春"

personal_names = [
    personal_names_1,
]

batch_first_last_name_in = NamsorClient::BatchFirstLastNameIn.new
batch_first_last_name_in.personal_names = personal_names

begin
    response = NamsorClient::JapaneseApi.new.japanese_name_latin_candidates_batch(
        {
            batch_first_last_name_in: batch_first_last_name_in,
        },
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling JapaneseApi#japanese_name_latin_candidates_batch: #{e}"
end
