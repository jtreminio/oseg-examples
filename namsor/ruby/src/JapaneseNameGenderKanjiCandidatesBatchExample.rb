require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

personal_names_1 = NamsorClient::FirstLastNameGenderIn.new
personal_names_1.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42"
personal_names_1.first_name = "Takashi"
personal_names_1.last_name = "Murakami"
personal_names_1.gender = "male"

personal_names = [
    personal_names_1,
]

batch_first_last_name_gender_in = NamsorClient::BatchFirstLastNameGenderIn.new
batch_first_last_name_gender_in.personal_names = personal_names

begin
    response = NamsorClient::JapaneseApi.new.japanese_name_gender_kanji_candidates_batch(
        {
            batch_first_last_name_gender_in: batch_first_last_name_gender_in,
        },
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling JapaneseApi#japanese_name_gender_kanji_candidates_batch: #{e}"
end
