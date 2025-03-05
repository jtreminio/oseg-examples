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

class CorridorBatchExample
{
    fun corridorBatch()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        val corridorFromTo1FirstLastNameGeoFrom = FirstLastNameGeoIn(
            id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            firstName = "Ada",
            lastName = "Lovelace",
            countryIso2 = "GB",
        )

        val corridorFromTo1FirstLastNameGeoTo = FirstLastNameGeoIn(
            id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            firstName = "Nicolas",
            lastName = "Tesla",
            countryIso2 = "US",
        )

        val corridorFromTo1 = CorridorIn(
            id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            firstLastNameGeoFrom = corridorFromTo1FirstLastNameGeoFrom,
            firstLastNameGeoTo = corridorFromTo1FirstLastNameGeoTo,
        )

        val corridorFromTo = arrayListOf<CorridorIn>(
            corridorFromTo1,
        )

        val batchCorridorIn = BatchCorridorIn(
            corridorFromTo = corridorFromTo,
        )

        try
        {
            val response = PersonalApi().corridorBatch(
                batchCorridorIn = batchCorridorIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PersonalApi#corridorBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PersonalApi#corridorBatch")
            e.printStackTrace()
        }
    }
}
