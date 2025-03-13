package oseg.launchdarkly_examples

import com.launchdarkly.client.infrastructure.*
import com.launchdarkly.client.apis.*
import com.launchdarkly.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class PutFlagSettingExample
{
    fun putFlagSetting()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val valuePut = ValuePut(
            comment = "make sure this context experiences a specific variation",
        )

        try
        {
            UserSettingsApi().putFlagSetting(
                projectKey = "projectKey_string",
                environmentKey = "environmentKey_string",
                userKey = "userKey_string",
                featureFlagKey = "featureFlagKey_string",
                valuePut = valuePut,
            )
        } catch (e: ClientException) {
            println("4xx response calling UserSettingsApi#putFlagSetting")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling UserSettingsApi#putFlagSetting")
            e.printStackTrace()
        }
    }
}
