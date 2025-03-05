package oseg.namsor_examples

import app.namsor.client.infrastructure.*
import app.namsor.client.apis.*
import app.namsor.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class JapaneseNameGenderKanjiCandidatesBatchExample
{
    fun japaneseNameGenderKanjiCandidatesBatch()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        val personalNames1 = FirstLastNameGenderIn(
            id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            firstName = "Takashi",
            lastName = "Murakami",
            gender = "male",
        )

        val personalNames = arrayListOf<FirstLastNameGenderIn>(
            personalNames1,
        )

        val batchFirstLastNameGenderIn = BatchFirstLastNameGenderIn(
            personalNames = personalNames,
        )

        try
        {
            val response = JapaneseApi().japaneseNameGenderKanjiCandidatesBatch(
                batchFirstLastNameGenderIn = batchFirstLastNameGenderIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling JapaneseApi#japaneseNameGenderKanjiCandidatesBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling JapaneseApi#japaneseNameGenderKanjiCandidatesBatch")
            e.printStackTrace()
        }
    }
}
