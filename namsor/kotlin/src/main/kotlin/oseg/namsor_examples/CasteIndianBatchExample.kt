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

class CasteIndianBatchExample
{
    fun casteIndianBatch()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        val personalNames1 = FirstLastNameGeoSubdivisionIn(
            id = "id",
            firstName = "firstName",
            lastName = "lastName",
            countryIso2 = "countryIso2",
            subdivisionIso = "subdivisionIso",
        )

        val personalNames2 = FirstLastNameGeoSubdivisionIn(
            id = "id",
            firstName = "firstName",
            lastName = "lastName",
            countryIso2 = "countryIso2",
            subdivisionIso = "subdivisionIso",
        )

        val personalNames = arrayListOf<FirstLastNameGeoSubdivisionIn>(
            personalNames1,
            personalNames2,
        )

        val batchFirstLastNameGeoSubdivisionIn = BatchFirstLastNameGeoSubdivisionIn(
            personalNames = personalNames,
        )

        try
        {
            val response = IndianApi().casteIndianBatch(
                batchFirstLastNameGeoSubdivisionIn = batchFirstLastNameGeoSubdivisionIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling IndianApi#casteIndianBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling IndianApi#casteIndianBatch")
            e.printStackTrace()
        }
    }
}
