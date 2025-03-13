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
class ChineseNameCandidatesBatchExample
{
    fun chineseNameCandidatesBatch()
    {
        ApiClient.apiKey["X-API-KEY"] = "YOUR_API_KEY"

        val personalNames1 = FirstLastNameIn(
            id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            firstName = "LiYing",
            lastName = "Zhao",
        )

        val personalNames = arrayListOf<FirstLastNameIn>(
            personalNames1,
        )

        val batchFirstLastNameIn = BatchFirstLastNameIn(
            personalNames = personalNames,
        )

        try
        {
            val response = ChineseApi().chineseNameCandidatesBatch(
                batchFirstLastNameIn = batchFirstLastNameIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ChineseApi#chineseNameCandidatesBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ChineseApi#chineseNameCandidatesBatch")
            e.printStackTrace()
        }
    }
}
