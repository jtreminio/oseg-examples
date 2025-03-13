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
class SubclassificationIndianFullBatchExample
{
    fun subclassificationIndianFullBatch()
    {
        ApiClient.apiKey["X-API-KEY"] = "YOUR_API_KEY"

        val personalNames1 = PersonalNameGeoIn(
            id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            name = "Jannat Rahmani",
        )

        val personalNames = arrayListOf<PersonalNameGeoIn>(
            personalNames1,
        )

        val batchPersonalNameGeoIn = BatchPersonalNameGeoIn(
            personalNames = personalNames,
        )

        try
        {
            val response = IndianApi().subclassificationIndianFullBatch(
                batchPersonalNameGeoIn = batchPersonalNameGeoIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling IndianApi#subclassificationIndianFullBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling IndianApi#subclassificationIndianFullBatch")
            e.printStackTrace()
        }
    }
}
