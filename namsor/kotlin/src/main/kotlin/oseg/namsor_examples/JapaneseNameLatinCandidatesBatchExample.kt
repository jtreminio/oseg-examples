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

class JapaneseNameLatinCandidatesBatchExample
{
    fun japaneseNameLatinCandidatesBatch()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        val personalNames1 = FirstLastNameIn(
            id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            firstName = "塩田",
            lastName = "千春",
        )

        val personalNames = arrayListOf<FirstLastNameIn>(
            personalNames1,
        )

        val batchFirstLastNameIn = BatchFirstLastNameIn(
            personalNames = personalNames,
        )

        try
        {
            val response = JapaneseApi().japaneseNameLatinCandidatesBatch(
                batchFirstLastNameIn = batchFirstLastNameIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling JapaneseApi#japaneseNameLatinCandidatesBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling JapaneseApi#japaneseNameLatinCandidatesBatch")
            e.printStackTrace()
        }
    }
}
